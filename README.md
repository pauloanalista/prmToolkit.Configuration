# prmToolkit.Configuration
Da suporte a obter informações do AppSettins do WebConfig ou AppConfig, dando uma mensagem de exceção tratada caso seja esperado uma chave que não foi definida no arquivo pelo desenvolvedor.

### Installation - prmToolkit.Configuration

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo ou acesse via Nuget:

```sh
Install-Package prmToolkit.Configuration -Version 1.0.1
```

## Obtendo informações do AppSettings

```csharp
//Namespace
//using prmToolkit.Configuration;

string valor = Configuration.GetKeyAppSettings("chave");
```

## Obtendo informações do ConnectionString

```csharp
//Namespace
//using prmToolkit.Configuration;

string valor = Configuration.GetConnectionString("Conexao");
```

## Obtendo informações do AppSettings com arquivo de configuração já criptografado

```csharp
//Namespace
//using prmToolkit.Configuration;

string valor = Configuration.GetKeyAppSettingsProtected("chave");
```

## Obtendo informações do ConnectionString com arquivo de configuração já criptografado

```csharp
//Namespace
//using prmToolkit.Configuration;

string valor = Configuration.GetConnectionStringProtected("Conexao");
```

## Criptografando arquivo de configuração

```csharp
//Namespace
//using prmToolkit.Configuration;

Configuration.ProtectConfigurationFile();
```

## Descriptografando arquivo de configuração

```csharp
//Namespace
//using prmToolkit.Configuration;

Configuration.UnprotectConfigurationFile();
```

## Arquivo de configuração Descriptografado

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="chave" value="valor"/>
  </appSettings>

  <connectionStrings>
    <add name="Conexao" connectionString="MinhaConexao"/>
  </connectionStrings>

  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.2" />
  </startup>
</configuration>
```

## Arquivo de configuração Criptografado

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="chave" value="valor" />
  </appSettings>
  <connectionStrings configProtectionProvider="RsaProtectedConfigurationProvider">
    <EncryptedData Type="http://www.w3.org/2001/04/xmlenc#Element"
      xmlns="http://www.w3.org/2001/04/xmlenc#">
      <EncryptionMethod Algorithm="http://www.w3.org/2001/04/xmlenc#aes256-cbc" />
      <KeyInfo xmlns="http://www.w3.org/2000/09/xmldsig#">
        <EncryptedKey xmlns="http://www.w3.org/2001/04/xmlenc#">
          <EncryptionMethod Algorithm="http://www.w3.org/2001/04/xmlenc#rsa-1_5" />
          <KeyInfo xmlns="http://www.w3.org/2000/09/xmldsig#">
            <KeyName>Rsa Key</KeyName>
          </KeyInfo>
          <CipherData>
            <CipherValue>O1FgA9doOGlLokKytJUKSg4BLghfbgYpEP2jh6yY2gy307wGCoeMTnWLbEWhiGi7XBhIf6TP+3elat0l1M+Q30w3TCt29/ZFe9UoP0vqB03KzS4uoH29inF/K++dW1GHePhg1lhkkyY9YEaY6eTHLi4JpMVpJ9IhiBxUMYCrKMlnmztogztSDTE3kfRHYswZzTKa9Jknhh3x3faOTVnPRVdb4evJhWpFyQHlptdFYN9T6M+hT8DQtgPx4dImFrf5m8UHWdYLU46dWE8CT0iyY0EduWs5O7lWdss9MAkALAlKKuSgDKa1FI+gNZtJ2rMRr9shaQs1K64ooS0JgaQ/OA==</CipherValue>
          </CipherData>
        </EncryptedKey>
      </KeyInfo>
      <CipherData>
        <CipherValue>DSeu8fzrt+GkneRLsuf1EObmqHsELAHT17+XHXNf2Lx96qHsF04pfKDDlYasb8JDJvk3Qa2H6iKJq8rGW3EhJBq6Irok8s/6Jsf260RryH7bd0/au0aoHghDsBwYGkHF40Jxk0OSxWk+G8x/ANYK93KWsuVn3MRPm+okyRrdM+o=</CipherValue>
      </CipherData>
    </EncryptedData>
  </connectionStrings>
```

