# dot_net
## Запуск тестов из консоли
<code>dotnet test --filter "FullyQualifiedName=PlayWright_Simple.SimpleGeneralTest"</code>

## Запуск тестов из консоли с браузером
<code>HEADED=1 dotnet test --filter "FullyQualifiedName=PlayWright_Simple.SimpleGeneralTest"</code>
<br>
<code>dotnet test --settings:chromium.runsettings</code>