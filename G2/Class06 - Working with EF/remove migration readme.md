# EF Migration Options

## **1. Creating Migration**

Once we create or change our models in the application, adding and removing migrations are normal part of the development process.

### To add a migration we use the command: 

```properties
Add-Migration initial
// initial is the file name suffix
```

The migration name can be used like a commit message in a version control system. For example, you might choose a name like **initial** if it's your first migration.

Three files are added to your project under the Migrations directory:

- **XXXXXXXXXXXXXX_initial.cs** -- The main migrations file. Contains the operations necessary to apply the migration (in Up) and to revert it (in Down).

- **XXXXXXXXXXXXXX_initial.Designer.cs** --The migrations metadata file. Contains information used by EF.

- **MyContextModelSnapshot.cs** -- A snapshot of your current model. Used to determine what changed when adding the next migration.

XXXXXXXXXXXXXX here represents the timestamp in the filename helps keep them ordered chronologically so you can see the progression of changes.

## **2. Restore and Remove a Migration**

If you have created migration or your current migration is fine, learn this option for the future.

In the development process we can make mistakes and there is a option to restore our database schema to a previous point.

### To restore our Migration, use this command:

```properties
Update-Database –TargetMigration: {name of the last good migration}
```

*Use command 'Get-Migrations' to get a list of the migration names that have been applied to your database.*

```properties
PM> Get-Migrations
Retrieving migrations that have been applied to the target database.
XXXXXXXXXXXXXX_Last_Bad_Migration
XXXXXXXXXXXXXX_Second_Migration
XXXXXXXXXXXXXX_Initial
```

Once you are on the state with the correct migration, you can delete the bad migration.

#### Remove migration with the command:

```properties
remove-migration 
```
We don't remove migrations manually!!! Doing it manually will not update the snapshot. We do it by using 
the Remove-migration command. It removes the last added migration. If we want to remove three migrations we will use this command three times. It will
remove the last migration, the one before it, and the one before that one.

At this point, you are free to create a new migration and apply it to the database.

## **3. Apply Migrations to the Database**

This step is to synchronize our last migrations with the database.

#### Command:

```properties
Update-database
```