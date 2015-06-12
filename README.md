# AzureResourceConnector
This Azure API App allows you to use Logic Apps to create / update / delete resources in Azure 

## Use the Azure Resource Connector in your Logic app

In just a few steps you can start using the Azure Resource Connector in your Logic app.

1. Before you can start using the Connector, you need to set up a Service Principal with permissions to do whatever it is you want to do in Azure. All calls will be made on-behalf-of this Service Principal that you set up.
    [David Ebbo has written a great blog post on how to set this up](http://blog.davidebbo.com/2014/12/azure-service-principal.html). Please follow all the instructions there and get your Tenant ID, Client ID and Secret. 
2. Next, clone the repository to your local machine. To follow these steps you'll want to use VS 2013 or VS 2015 with Azure SDK 2.6 installed.
3. Open the Solution in VS and open the **Web.config** file. Update the following fields with the values from step 1 (and your Azure subscription ID):
```
<add key="AzureResourceConnector_TenantId" value="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" />
<add key="AzureResourceConnector_SubscriptionId" value="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" />
<add key="AzureResourceConnector_ClientId" value="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" />
<add key="AzureResourceConnector_ClientSecret" value="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" />
```
    *Note: technically, the right way to do this would be to only update these settings for your running API App, but I find it easier this way so that you can run locally if you want.* 
4. Feel free to **Build** and run Locally to make sure everything works. You won't be able to go to the root page, but you can navigate to `locahost:PORT/swagger` and see all of the operations in the API app. 
5. Now Right-Click on the **Azure Resource Connector** project in the Solution Explorer and select **Publish**. 
6. For publishing target select **Microsoft Azure API App (Preview)**. Then sign in to Azure if you haven't already, and click **New**.
7. At this point you'll fill out the settings for your API App. Choose where you want to deploy it and click **OK**. Now you need to wait for the API App to be deployed.
8. Once it's been deployed, Right-Click again and select **Publish** again.
9. Now you should just be able to click the **Publish** button and off you go.
10. After that's fininshed, you can go to the Azure Portal and select new **Logic app**. Be sure to choose the same Resource Group and App Service Plan as the one you deployed the API App to.
11. You should see the Azure Resource Connector in the right-hand pane. You can click it and use it as a Trigger (on events or metrics), or, you can put some other trigger in (say, a recurrence), and then use any of the actions in the connector.
12. Once you save the Logic app you should be able to use it to manage anything in your Azure Subscirption.
