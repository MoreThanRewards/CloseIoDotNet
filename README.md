# CloseIoDotNet

A library for interacting with the [Close.io CRM](http://close.io) [API](http://developer.close.io/).

# Author

[More Than Rewards](http://www.morethanrewards.com/)

Maintained by [Tony Lechner](https://github.com/tonymke), tony@morethanrewards.com, Software Engineer at More Than Rewards

# Legal Note

CloseIoDotNet is a third party API abstraction library. More Than Rewards is not 
affiliated with Elastic, Inc, owners of the Close.Io service and trademark, in any way.

# License

MIT. See LICENSE.txt.

# Status

First beta release (0.1) complete - reading from all lead-based endpoints
implemented.

Second beta release (0.2) under active development.

# How to

Read single records by ID with **Queries**, or read multiple records with **Scans**.

Currently, reading of any lead-based record type (Lead, Address, Contact, Contact URL, Contact Phone, Contact Email, Opportunity, and Task objects) are supported.

## Example: Query a specific lead

```cs
using (var context = new CloseIoDotNetContext("VALID CLOSE.IO API KEY"))
{
	return context.Query<Lead>("LEAD ID");
}
```

## Example: Scan all leads
```cs
using (var context = new CloseIoDotNetContext("VALID CLOSE.IO API KEY"))
{
	return context.Scan<Lead>();
}
```

## Example: Scan for the names of all contacts with a specific phone number.
```cs
using (var context = new CloseIoDotNetContext("VALID CLOSE.IO API KEY"))
{
	var fieldsToSearch = (new Lead()).EntityFields.Where(entry => entry.SerializedName.Equals("contacts"));
	var searchQuery = "phone_number:111-222-3344";
	return context.Scan<Lead>(searchQuery, fieldsToSearch)
		.SelectMany(entry => entry.Contacts)
		.Select(entry => entry.Name);
}
```

# Roadmap

* ~~**0.1** Read from all lead-based endpoints described on [developer.close.io](http://developer.close.io)~~
* **0.2** Full CRUD on all lead-based endpoints where supported
* **0.3** Read from ALL endpoints described on [developer.close.io](http://developer.close.io)
* **0.4** Full CRUD on ALL endpoints described on [developer.close.io](http://developer.close.io)
* **0.5** Add full support for line-level custom field updates.
* **0.6** Add full support for integration link field CRUD
* **1.0** Fully tested, non-beta release.
* **1.1** Add query string builder
