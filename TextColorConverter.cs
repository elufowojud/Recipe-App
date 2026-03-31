<?xml version="1.0" encoding="UTF-8" ?>
<Shell
    x:Class="RecipeApp.AppShell"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:views="clr-namespace:RecipeApp.Views"
    Title="RecipeApp">

    <TabBar>
        <Tab Title="Home">
            <ShellContent ContentTemplate="{DataTemplate views:HomePage}" />
        </Tab>

        <Tab Title="Recipes">
            <ShellContent ContentTemplate="{DataTemplate views:RecipeListPage}" />
        </Tab>

        <Tab Title="Favorites">
            <ShellContent ContentTemplate="{DataTemplate views:FavoritesPage}" />
        </Tab>

        <Tab Title="Search">
            <ShellContent ContentTemplate="{DataTemplate views:SearchPage}" />
        </Tab>
    </TabBar>

</Shell>