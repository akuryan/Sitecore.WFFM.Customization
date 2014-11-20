Sitecore.WFFM.Customization
===========================
This repository would be used to store several self-developed or found on Internet additions to Sitecore WFFM (Web Forms For Marketeers).

###Limitations
Could be used with Sitecore non less than 6.5

### WFFM Edit button and disabling of InsertButton
Developed by Mikkel Holck Madsen and shared by him in following blog posts:

[Adding Edit button](http://www.mikkelhm.dk/post/2013/09/03/Adding-an-edit-button-to-the-Web-Forms-for-Marketers-module.aspx);
Before starting, either deserialize items from /Sitecore Items/Edit button/serialization/, or install package /Sitecore Items/Edit button/WFFMEditButton.zip
This one would substitute Insert form button by Edit form button if on Sitecore Device, defined in configuration file, form interpreter with valid form is present.
Would be working with WFFM 2.1 rev 100920


[Improving Insert form button](http://www.mikkelhm.dk/post/2013/09/08/Improving-the-Insert-form-button-on-the-Webforms-for-Marketers-module.aspx);
This one would hide insert button, if on Sitecore Device, defined in configuration file, form interpreter with valid form is present.
However, it would be useful only in case you have one device used for WebForms delivery
Would be working with WFFM 2.1 rev 100920

### AllFields token
WFFM.Customization.AllFieldsProcessor.config and /sitecore/shell/override/SendEmail.xml could be removed in oder to remove this functionality
This one is responsible for adding special token in Rich Text editor in SendEmail editor.
This token could be used to insert all form fields in generated email message (instead of tediously adding field by field).
Would be working with WFFM 2.1 rev 100920


##Usage
After some investigations and ideas, I decided to compile all code in one assembly, but allow granular control of what is needed by adding different config files for App_config/Include.
So, one could disable unneeded feature by just removing it's configuration.
If you have already modified /sitecore/shell/override/SendEmail.xml - you should recompile module against your modified assembly
