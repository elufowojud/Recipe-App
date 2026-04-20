# RecipeBox - .NET MAUI Recipe Management Application

A comprehensive cross-platform recipe management application built with .NET MAUI, featuring local SQLite storage, external API integration, and modern MVVM architecture.

## 📱 Features-

### Core Functionality
- **Full CRUD Operations** - Create, Read, Update, and Delete recipes
- **Local Database** - SQLite database with persistent storage
- **External API Integration** - Browse and import recipes from TheMealDB API
- **Search & Filter** - Search recipes by name and filter by category
- **Favorites System** - Mark recipes as favorites and view them in a dedicated page
- **Category Browsing** - Browse recipes by Breakfast, Lunch, Dinner, and Dessert

### User Interface
- 7 fully functional pages with Shell navigation
- 4-tab bottom navigation (Home, Recipes, Favorites, Search)
- Dynamic forms for adding and editing recipes
- Real-time UI updates with ObservableCollections
- Confirmation dialogs for destructive actions
- Loading indicators for API operations

## 🏗️ Architecture

### MVVM Pattern
- **8 ViewModels** implementing MVVM architecture
- **Models** - Recipe with JSON serialization for complex data types
- **Views** - XAML pages with data binding
- **Services** - Repository and API service layers

### Design Patterns (6 Implemented)
1. **MVVM** - Model-View-ViewModel separation
2. **Repository Pattern** - DatabaseContext abstracts data access
3. **Dependency Injection** - Constructor injection throughout
4. **Observer Pattern** - ObservableCollection and INotifyPropertyChanged
5. **Command Pattern** - RelayCommand for user actions
6. **Singleton Pattern** - Single DatabaseContext instance

See [DESIGN_PATTERNS.md](DESIGN_PATTERNS.md) for detailed documentation.

## 🛠️ Technology Stack

- **.NET MAUI** - Cross-platform framework
- **SQLite-net-pcl** - Local database
- **CommunityToolkit.Mvvm** - MVVM helpers and source generators
- **System.Text.Json** - JSON serialization/deserialization
- **HttpClient** - REST API consumption
- **C# 12** - Modern C# features

## 📂 Project Structure
```
RecipeApp/
├── Models/
│   └── Recipe.cs                    # Recipe data model
├── ViewModels/
│   ├── BaseViewModel.cs             # Base class for all ViewModels
│   ├── HomeViewModel.cs             # Home page logic
│   ├── RecipeListViewModel.cs       # Recipe list and category filtering
│   ├── RecipeDetailViewModel.cs     # Recipe details with edit/delete
│   ├── AddRecipeViewModel.cs        # Add new recipe
│   ├── EditRecipeViewModel.cs       # Edit existing recipe
│   ├── FavoritesViewModel.cs        # Favorites management
│   ├── SearchViewModel.cs           # Search functionality
│   └── BrowseApiViewModel.cs        # API browsing and import
├── Views/
│   ├── HomePage.xaml                # Landing page with categories
│   ├── RecipeListPage.xaml          # Recipe list display
│   ├── RecipeDetailPage.xaml        # Recipe details view
│   ├── AddRecipePage.xaml           # Add recipe form
│   ├── EditRecipePage.xaml          # Edit recipe form
│   ├── FavoritesPage.xaml           # Favorites list
│   ├── SearchPage.xaml              # Search interface
│   └── BrowseApiPage.xaml           # API recipe browser
├── Services/
│   ├── DatabaseContext.cs           # SQLite repository
│   └── MealDbService.cs             # TheMealDB API service
├── ApiModels/
│   └── MealDbResponse.cs            # API response models
├── Converters/
│   └── InvertedBoolConverter.cs     # UI state converter
└── DESIGN_PATTERNS.md               # Design patterns documentation
```

## 🗄️ Database Schema

### Recipe Model
```csharp
public class Recipe
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Category { get; set; }
    public int PrepTime { get; set; }
    public bool IsFavorite { get; set; }
    
    // Serialized as JSON
    public List<string> Ingredients { get; set; }
    public List<string> Instructions { get; set; }
}
```

## 🌐 External API Integration

### TheMealDB API
- **Endpoint**: https://www.themealdb.com/api/json/v1/1
- **Features**:
  - Search recipes by name
  - Get random recipes
  - Recipe details with images
  - Import to local database

### API Operations
```csharp
// Search recipes
await _apiService.SearchRecipesByNameAsync("chicken");

// Get random recipes
await _apiService.GetRandomRecipesAsync(10);

// Import to local database
await _database.SaveRecipeAsync(convertedRecipe);
```

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 (17.8 or later)
- .NET 8.0 SDK
- Windows 10 SDK (10.0.17763.0 or later)

### Installation
1. Clone the repository
```bash
   git clone https://github.coventry.ac.uk/6004CMD-25-26/6004CMD_Elufowoju_David.git
```

2. Open `RecipeApp.sln` in Visual Studio 2022

3. Restore NuGet packages
```
   Tools → NuGet Package Manager → Restore NuGet Packages
```

4. Build and run
```
   Press F5 or click "Windows Machine" in the toolbar
```

## 📦 NuGet Packages
```xml
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.2.2" />
<PackageReference Include="sqlite-net-pcl" Version="1.9.172" />
<PackageReference Include="SQLitePCLRaw.bundle_green" Version="2.1.8" />
```

## 💾 Data Persistence

### Local Storage
- SQLite database stored in app data directory
- Automatic initialization with 5 seed recipes
- JSON serialization for complex data types (lists)

### Seed Data
- Fluffy Pancakes (Breakfast)
- Caesar Salad (Lunch)
- Spaghetti Carbonara (Dinner)
- Chocolate Cake (Dessert)
- French Toast (Breakfast)

## 🎨 User Interface Features

### Dynamic Forms
- Add/Edit recipes with real-time validation
- Dynamic ingredient and instruction lists
- Add/Remove buttons for list management
- Category picker with 5 categories
- Numeric keyboard for prep time

### Navigation
- Shell-based navigation with routes
- Bottom tab bar (Home, Recipes, Favorites, Search)
- Forward/back navigation stack
- Deep linking support

## 🔧 Key Implementation Details

### CRUD Operations
```csharp
// Create
await _database.SaveRecipeAsync(newRecipe);

// Read
var recipe = await _database.GetRecipeAsync(id);
var recipes = await _database.GetRecipesByCategoryAsync("Dinner");

// Update
recipe.Name = "Updated Name";
await _database.SaveRecipeAsync(recipe);

// Delete
await _database.DeleteRecipeAsync(recipe);
```

### Dependency Injection
```csharp
// MauiProgram.cs
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddSingleton<MealDbService>();
builder.Services.AddTransient<RecipeListViewModel>();
```

### Data Binding
```xml
<Label Text="{Binding Recipe.Name}" />
<Button Command="{Binding DeleteRecipeCommand}" />
<ListView ItemsSource="{Binding Recipes}" />
```

## 📊 Application Flow

1. **Home Page** → Select category or browse online recipes
2. **Recipe List** → View recipes by category
3. **Recipe Details** → View full recipe with edit/delete options
4. **Add/Edit** → Create or modify recipes
5. **Favorites** → View favorited recipes
6. **Search** → Find recipes by name
7. **Browse API** → Search and import online recipes

## 🧪 Testing

### Manual Testing Performed
- ✅ All CRUD operations
- ✅ Category filtering
- ✅ Search functionality
- ✅ Favorites toggle
- ✅ API search and import
- ✅ Form validation
- ✅ Navigation flows
- ✅ Data persistence


### Requirements Met
- ✅ Project structure with 7+ folders
- ✅ 7 pages with navigation
- ✅ 9+ UI controls
- ✅ MVVM architecture with 8 ViewModels
- ✅ Dependency injection
- ✅ SQLite database with full CRUD
- ✅ Data persistence
- ✅ 6 design patterns (exceeds requirement of 4)
- ✅ External API integration
- ✅ Git repository with commits
- ✅ Professional documentation

## 🐛 Known Issues

### Windows Text Rendering
Some text elements may appear with reduced visibility on Windows dark mode due to a known .NET MAUI rendering issue. Workaround implemented: explicit color values and manual UI rendering.

## 🔮 Future Enhancements

- [ ] Image upload for recipes
- [ ] Recipe ratings and reviews
- [ ] Shopping list generation
- [ ] Meal planning calendar
- [ ] Recipe sharing
- [ ] Cloud synchronization
- [ ] Unit tests
- [ ] UI tests

## 📄 License

This is an academic project for Coventry University.

## 👤 Author

**David Elufowoju**
- Student ID: 13122803
- Module: 6004CMD - Advanced Mobile App Development
- Academic Year: 2025-2026

## 🙏 Acknowledgments

- TheMealDB API for providing free recipe data
- .NET MAUI team for the cross-platform framework
- CommunityToolkit.Mvvm for MVVM helpers
- Coventry University for project guidance

---

