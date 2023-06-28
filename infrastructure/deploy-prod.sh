#!/bin/bash

# Declare a resource group variable
export RESOURCE_GROUP_NAME=rg-plastico-database-fra-prod
az group create --name $RESOURCE_GROUP_NAME --location francecentral

# Generate a GUID and store it in a variable
export PASSWORD=$(uuidgen)

az deployment group create --resource-group $RESOURCE_GROUP_NAME --template-file postgres-db.bicep --parameters environment=prod administratorPassword=$PASSWORD

# Echo the password to the console
echo $PASSWORD

az keyvault secret set --vault-name plastico-keyvault-prod --name "postgres-prod-admin-password" --value $PASSWORD