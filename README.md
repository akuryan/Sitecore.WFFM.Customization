Sitecore.WFFM.Customization
===========================
This repository would be used to store several self-developed or found on Internet additions to Sitecore WFFM (Web Forms For Marketeers).

###Limitations
Could be used with Sitecore non less than 6.5

### WFFM Edit button and disabling of InsertButton
Developed by Mikkel Holck Madsen and shared by him in following blog posts:
[Adding Edit button](http://www.mikkelhm.dk/post/2013/09/03/Adding-an-edit-button-to-the-Web-Forms-for-Marketers-module.aspx);
Before starting, either deserialize items from /Sitecore Items/Edit button/serialization/, or install package /Sitecore Items/Edit button/WFFM Edit button.zip
[Improving Insert form button](http://www.mikkelhm.dk/post/2013/09/08/Improving-the-Insert-form-button-on-the-Webforms-for-Marketers-module.aspx);

##Usage
After some investigations and ideas, I decided to compile all code in one assembly, but allow granular control of what is needed by adding different config files for App_config/Include.
So, one could disable unneeded feature by just removing it's configuration