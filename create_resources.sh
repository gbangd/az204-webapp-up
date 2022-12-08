#!/bin/sh
#Set varibles
rg="rgimagecreator"
sta="staimagecreator"
ct="ctimagecreator"
lc="EastUS2"
asp="aspimagecreator"

#1. Create resource group 
az group create -n $rg -l $lc 
#2. Create storage account
az storage account create -n $sta -l $lc -g $rg
#3. Create blob container
az storage container create -n $ct --account-name $sta --public-access blob
#4. Create App Service Plan
az appservice plan create -n $asp --sku S1 -g $rg -l $lc
#5. Create WebApp
az webapp create -g $rg -n wapimagecreator --plan $asp 
#6. Get connection string
az storage account show-connection-string -n $sta -g $rg
