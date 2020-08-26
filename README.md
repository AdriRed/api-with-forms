# API with Windows Forms

## Ramas

- master
  - API: .NET Core 3.1
  - Models: .NET Standard 2.0
  - Front: .NET Framework 4.7.2
- net5
  - API, Models, Front: .NET 5.0 (requerido .NET 5.0 [version preliminar](https://dotnet.microsoft.com/download/dotnet/5.0) o [Visual Studio Preview](https://visualstudio.microsoft.com/es/vs/preview/) )

## Para ejecutar este proyecto

- Configura la solución para que tenga multiples proyectos de inicio:
  - *APIWithForms.API*
  - *APIWithForms.Front*
- Puede ser que la referencia del proyecto *APIWithForms.Front* a *APIWithForms.Model* esté rota. Vuelve a referenciarlo. O
- Compila dos veces.
