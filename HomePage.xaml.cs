<?xml version="1.0" encoding="UTF-8" ?>
<ResourceDictionary 
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <Style TargetType="ActivityIndicator">
        <Setter Property="Color" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
    </Style>

    <Style TargetType="IndicatorView">
        <Setter Property="IndicatorColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}"/>
        <Setter Property="SelectedIndicatorColor" Value="{AppThemeBinding Light={StaticResource Gray950}, Dark={StaticResource Gray100}}"/>
    </Style>

    <Style TargetType="Border">
        <Setter Property="Stroke" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}" />
        <Setter Property="StrokeShape" Value="Rectangle"/>
        <Setter Property="StrokeThickness" Value="1"/>
    </Style>

    <Style TargetType="BoxView">
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource Gray950}, Dark={StaticResource Gray200}}" />
    </Style>

    <Style TargetType="Button">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource PrimaryDarkText}}" />
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="BorderWidth" Value="0"/>
        <Setter Property="CornerRadius" Value="8"/>
        <Setter Property="Padding" Value="14,10"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray950}, Dark={StaticResource Gray200}}" />
                            <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="PointerOver" />
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="CheckBox">
        <Setter Property="Color" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="Color" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="DatePicker">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <Style TargetType="Editor">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14" />
        <Setter Property="PlaceholderColor" Value="Gray" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <Style TargetType="Entry">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14" />
        <Setter Property="PlaceholderColor" Value="Gray" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <Style TargetType="ImageButton">
        <Setter Property="Opacity" Value="1" />
        <Setter Property="BorderColor" Value="Transparent"/>
        <Setter Property="BorderWidth" Value="0"/>
        <Setter Property="CornerRadius" Value="0"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <!-- FORCE BLACK TEXT FOR ALL LABELS -->
    <Style TargetType="Label">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular" />
        <Setter Property="FontSize" Value="14" />
    </Style>

    <Style TargetType="Label" x:Key="Headline">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="FontSize" Value="32" />
        <Setter Property="HorizontalOptions" Value="Center" />
        <Setter Property="HorizontalTextAlignment" Value="Center" />
    </Style>

    <Style TargetType="Label" x:Key="SubHeadline">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="FontSize" Value="24" />
        <Setter Property="HorizontalOptions" Value="Center" />
        <Setter Property="HorizontalTextAlignment" Value="Center" />
    </Style>

    <Style TargetType="Picker">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="TitleColor" Value="Black" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <Style TargetType="ProgressBar">
        <Setter Property="ProgressColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
    </Style>

    <Style TargetType="RadioButton">
        <Setter Property="BackgroundColor" Value="Transparent"/>
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <Style TargetType="RefreshView">
        <Setter Property="RefreshColor" Value="Black" />
    </Style>

    <Style TargetType="SearchBar">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="PlaceholderColor" Value="Gray" />
        <Setter Property="CancelButtonColor" Value="Gray" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular" />
        <Setter Property="FontSize" Value="14" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <Style TargetType="SearchHandler">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="PlaceholderColor" Value="Gray" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular" />
        <Setter Property="FontSize" Value="14" />
    </Style>

    <Style TargetType="Shadow">
        <Setter Property="Radius" Value="15" />
        <Setter Property="Opacity" Value="0.5" />
        <Setter Property="Brush" Value="White" />
        <Setter Property="Offset" Value="10,10" />
    </Style>

    <Style TargetType="Slider">
        <Setter Property="MinimumTrackColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="MaximumTrackColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray600}}" />
        <Setter Property="ThumbColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
    </Style>

    <Style TargetType="SwipeItem">
        <Setter Property="BackgroundColor" Value="White" />
    </Style>

    <Style TargetType="Switch">
        <Setter Property="OnColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="ThumbColor" Value="White" />
    </Style>

    <Style TargetType="TimePicker">
        <Setter Property="TextColor" Value="Black" />
        <Setter Property="BackgroundColor" Value="Transparent"/>
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
    </Style>

    <Style TargetType="Page" ApplyToDerivedTypes="True">
        <Setter Property="Padding" Value="0"/>
        <Setter Property="BackgroundColor" Value="White" />
    </Style>

    <Style TargetType="Shell" ApplyToDerivedTypes="True">
        <Setter Property="Shell.BackgroundColor" Value="White" />
        <Setter Property="Shell.ForegroundColor" Value="Black" />
        <Setter Property="Shell.TitleColor" Value="Black" />
        <Setter Property="Shell.DisabledColor" Value="LightGray" />
        <Setter Property="Shell.UnselectedColor" Value="Gray" />
        <Setter Property="Shell.NavBarHasShadow" Value="False" />
        <Setter Property="Shell.TabBarBackgroundColor" Value="White" />
        <Setter Property="Shell.TabBarForegroundColor" Value="Black" />
        <Setter Property="Shell.TabBarTitleColor" Value="Black" />
        <Setter Property="Shell.TabBarUnselectedColor" Value="Gray" />
    </Style>

    <Style TargetType="NavigationPage">
        <Setter Property="BarBackgroundColor" Value="White" />
        <Setter Property="BarTextColor" Value="Black" />
        <Setter Property="IconColor" Value="Black" />
    </Style>

    <Style TargetType="TabbedPage">
        <Setter Property="BarBackgroundColor" Value="White" />
        <Setter Property="BarTextColor" Value="Black" />
        <Setter Property="UnselectedTabColor" Value="Gray" />
        <Setter Property="SelectedTabColor" Value="Black" />
    </Style>

    <!-- FORCE SPAN TEXT COLOR -->
    <Style TargetType="Span">
        <Setter Property="TextColor" Value="Black" />
    </Style>

</ResourceDictionary>