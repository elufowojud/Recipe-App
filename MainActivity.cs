# Design Patterns Implementation - RecipeApp

This document outlines the design patterns implemented in the RecipeApp project.

## 1. MVVM Pattern (Model-View-ViewModel)

### Description
Separates the user interface (View) from the business logic (ViewModel) and data (Model).

### Implementation
- **Models**: `Recipe.cs` - Represents recipe data structure
- **Views**: All XAML pages (HomePage.xaml, RecipeListPage.xaml, RecipeDetailPage.xaml, etc.)
- **ViewModels**: 8 ViewModels (HomeViewModel, RecipeListViewModel, RecipeDetailViewModel, AddRecipeViewModel, EditRecipeViewModel, FavoritesViewModel, SearchViewModel, BaseViewModel)

### Benefits
- Clear separation of concerns
- Testability (ViewModels can be unit tested)
- Maintainability
- Reusability of ViewModels

### Code Example
```csharp
// Model
public class Recipe
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
}

// ViewModel
public partial class RecipeListViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Recipe> recipes = new();
}

// View (XAML)
<ListView ItemsSource="{Binding Recipes}" />
```

---

## 2. Repository Pattern

### Description
Abstracts data access logic and provides a collection-like interface for accessing domain objects.

### Implementation
- **Repository**: `DatabaseContext.cs`
- Provides methods: `GetRecipesAsync()`, `SaveRecipeAsync()`, `DeleteRecipeAsync()`, `SearchRecipesAsync()`, etc.

### Benefits
- Centralized data access logic
- Easy to swap data sources (could change from SQLite to cloud)
- Testability (can mock the repository)
- Consistent data access across the app

### Code Example
```csharp
public class DatabaseContext
{
    public async Task<List<Recipe>> GetRecipesAsync()
    {
        await Init();
        return await _database.Table<Recipe>().ToListAsync();
    }
    
    public async Task<int> SaveRecipeAsync(Recipe recipe)
    {
        await Init();
        if (recipe.Id != 0)
            return await _database.UpdateAsync(recipe);
        else
            return await _database.InsertAsync(recipe);
    }
}
```

---

## 3. Dependency Injection Pattern

### Description
Provides dependencies to classes through constructor injection rather than having classes create their own dependencies.

### Implementation
- **DI Container**: MauiProgram.cs registers services
- **Services**: DatabaseContext, all ViewModels
- **Injection**: ViewModels receive DatabaseContext via constructor

### Benefits
- Loose coupling
- Testability (can inject mock dependencies)
- Flexibility (easy to change implementations)
- Follows SOLID principles

### Code Example
```csharp
// MauiProgram.cs - Registration
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddTransient<RecipeListViewModel>();
builder.Services.AddTransient<RecipeListPage>();

// ViewModel - Constructor Injection
public class RecipeListViewModel : BaseViewModel
{
    private readonly DatabaseContext _database;
    
    public RecipeListViewModel(DatabaseContext database)
    {
        _database = database; // Injected dependency
    }
}
```

---

## 4. Observer Pattern

### Description
Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified automatically.

### Implementation
- **Observable**: `ObservableCollection<Recipe>` in ViewModels
- **Observers**: UI elements bound to collections
- **INotifyPropertyChanged**: Implemented through `[ObservableProperty]` attribute

### Benefits
- Automatic UI updates when data changes
- Decouples UI from data
- No manual refresh needed

### Code Example
```csharp
// ViewModel
[ObservableProperty]
private ObservableCollection<Recipe> recipes = new();

// When items are added, UI automatically updates
public async Task LoadRecipesAsync()
{
    var loadedRecipes = await _database.GetRecipesAsync();
    Recipes.Clear();
    foreach (var recipe in loadedRecipes)
    {
        Recipes.Add(recipe); // UI notified automatically
    }
}
```

---

## 5. Command Pattern

### Description
Encapsulates a request as an object, allowing parameterization of clients with different requests, queuing of requests, and logging of operations.

### Implementation
- **Commands**: All `[RelayCommand]` methods in ViewModels
- **Examples**: SaveRecipeCommand, DeleteRecipeCommand, EditRecipeCommand, SearchCommand

### Benefits
- Encapsulates actions
- Enables undo/redo functionality (if implemented)
- Separation of action invocation from execution
- Easy to add new commands

### Code Example
```csharp
// ViewModel
[RelayCommand]
async Task DeleteRecipe()
{
    if (Recipe == null) return;
    
    bool confirm = await Shell.Current.DisplayAlert(
        "Delete Recipe",
        $"Are you sure you want to delete '{Recipe.Name}'?",
        "Delete",
        "Cancel");
    
    if (confirm)
    {
        await _database.DeleteRecipeAsync(Recipe);
        await Shell.Current.GoToAsync("..");
    }
}

// XAML - Command Binding
<Button Text="Delete Recipe" 
        Command="{Binding DeleteRecipeCommand}" />
```

---

## 6. Singleton Pattern (Implicit)

### Description
Ensures a class has only one instance and provides a global point of access to it.

### Implementation
- **Singleton**: DatabaseContext registered as `AddSingleton` in DI container
- Only one instance exists throughout app lifetime
- Shared across all ViewModels

### Benefits
- Single database connection
- Consistent state
- Resource efficiency
- Thread-safe (handled by DI container)

### Code Example
```csharp
// MauiProgram.cs
builder.Services.AddSingleton<DatabaseContext>(); // Single instance

// All ViewModels receive the SAME instance
public RecipeListViewModel(DatabaseContext database) { }
public RecipeDetailViewModel(DatabaseContext database) { }
// Both receive the same DatabaseContext instance
```

---

## Summary

The RecipeApp demonstrates **6 design patterns**:
1. ✅ MVVM Pattern - Core architecture
2. ✅ Repository Pattern - Data access abstraction
3. ✅ Dependency Injection - Loose coupling
4. ✅ Observer Pattern - Automatic UI updates
5. ✅ Command Pattern - Action encapsulation
6. ✅ Singleton Pattern - Single database instance

These patterns work together to create a maintainable, testable, and scalable application architecture following SOLID principles and best practices for .NET MAUI development.