# .NET Framework ASP.Net MVC application using SAML protocol to connect to Azure Active Directory (SSO)

## About the sample

This sample application demonstrates how an ASP.Net MVC web application integrates with Azure AD to delegate user Authentication using [SAML](https://docs.microsoft.com/azure/active-directory/develop/single-sign-on-saml-protocol) protocol. Therefore, providing SSO for the application.

## Prerequisites

- [Visual Studio](https://aka.ms/vsdownload)
- [.Net Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
- An Azure Active Directory (Azure AD) tenant.

## Register the SAML application to Azure Active Directory

1. Sign in to the [Azure Portal](https://portal.azure.com) using a tenant admin account.
2. Navigate to the Microsoft identity platform for developers [Enterprise applications](https://portal.azure.com/#blade/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/EnterpriseApps) page.
3. Click **New Application**
4. Click **Create your own application**
5. Select **Non gallery app**
6. Choos a name for the application. For instance 'SampleApp' and select **Create** on the bottom.
7. Under the Manage section, select **Single Sign-On**
8. Select **SAML** and the **Set up Single Sign-On with SAML** page will appear.

#### Basic SAML configuration for your application

1. To edit the basic SAML configuration options, select the **Edit** icon (a pencil) in the upper-right corner of the Basic SAML Configuration section.
2. Set **Identifier (Entity ID)** with an unique URL that follows the pattern, `http://{your-appName}.{your-domain}.com`. For instance: `http://SampleApp.contoso.com`. Copy the Entity ID value to be used in later steps.
3. Set **Reply URL** with the URL that Azure AD will reply after the authentication. In this sample we are using `https://localhost:44311/`.

Learn more about [configuring SAML-based single sign-on in Azure Active Directory](https://docs.microsoft.com/azure/active-directory/manage-apps/configure-single-sign-on-non-gallery-applications).

#### SAML Signing Certificate

1. In the **SAML Signing Certificate** section, if you don't have a certificate yet, select the **Edit** icon (a pencil) in the upper-right corner.
2. Select **New Certificate** and then **Save**.
3. Close the blade, refresh the page and copy the value for `App Federation Metadata Url` field. We will use it on the .NET MVC project.

## Configure the .NET MVC project (WebApp_SAML) to use your app registration

Open the project **WebApp_SAML** in your IDE (like Visual Studio) to configure the code.

1. Open the _Web.config_ file.
1. Replace the value for `ida:ADFSMetadata` with the link that you copied from **App Federation Metadata Url** field.
1. Replace the value for `ida:Wtrealm` with the value that you set for **Identifier (Entity ID)**. For instance, `http://SampleApp.contoso.com`.
1. Save, clean and build the solution.
