Observer Debriefing Web Application
===============

The Observer Debriefing Web Application is intended to allow for the entry
of trip debriefing in two scenarios:

1.  Electronic entry of existing debriefing worksheets
2.  Direct electronic entry of debriefing data

The web application is written in C# and uses Microsoft's MVC3 framework for the
presentation layer.  The data access layer uses Fluent NHibernate with a SQL Server
data store.

The following tasks have yet to be completed:

+ Adding a positive action modal dialog when changing gear type and/or workbook version
+ Adding a disclaimer regarding data ownership
+ Security
+ i18n work.  A resource holding field names exists, but nothing has been done to integrate it into the web tier