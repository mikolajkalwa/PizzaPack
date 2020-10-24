# PizzaPack

Repository created for recruitment process at Metapack Poland.

## Implemented features

- Ability to order any set of dishes.
- Each dish can be selected multiple times.
- Total price of selected dishes is updated as soon as the order changes.
- Order confirmation is send via email. (Emails are send via [Twilio Sendgrid](https://sendgrid.com/) service)
- Orders history
- Configuration stored in appsettings.json file.



## Running the project

### Requirements:

- MongoDB instance

- Sendgrid account



### Configuration:

For API project: 

1. Create Mongo Database, and populate it with data from [MetaPizza.archive](MetaPizza.archive) file, using `mongorestore`
2. In [appsettings](api/appsettings.json) file, in DatabaseSettings section, provide ConnectionString to MongoDB ([Connection String URI Format &mdash; MongoDB Manual](https://docs.mongodb.com/manual/reference/connection-string/))
3. In the same appsettings file, in SendGridSettings section, provide an apikey for SendGrid account and email address from which emails should be send to the end user. 



For GUI project:

1. In [appsettings](gui/appsettings.json) file provide API address.
