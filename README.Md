# Cloud DNS Api Wrapper for [Certify The Web Software](https://certifytheweb.com/)

Certify The Web Software helps admin to easily install and auto-renew free SSL/TLS certificates from [letsencrypt.org](https://letsencrypt.org) and other ACME Certificate Authorities for your IIS/Windows servers. 
Setting up https has never been easier.
[ArvanCloud](https://www.arvancloud.com/en/about), an international cloud services provider in Germany, offers various effective solutions for its customers worldwide.

## The problem we cover

Certify uses API based DNS management for authorization, it supports a lot of cloud DNS providers but supporting Arvancloud yet.
So I made this wrapper to connect Arvancloud API from Certify and authorize the ACME DNS validator records.
You may find the image below for how to set up the environment.


### Don't forget to replace my sample API key in the config file.
![alt text](https://github.com/AmirDez/Images/CloudDnsWrapper.jpg "How to setup")

