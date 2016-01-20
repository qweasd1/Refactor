### bool condition
* [*]array(),null,0,false will represent false

### Basics- Control flow
* return from script: exit()
* try-catch syntax:
```php
try
{
    //do something risky
}
catch (ExceptionType $e)
{
   //handle the exception
}

```


### Html Template

* add <meta charset="utf-8"> to the head of your html



### Http requrest
* $_REQUEST will contain both variables defined in $_GET and $_POST
* 

### DB Operation
* new PDO('mysql:host=hostname;dbname=database', 'username', 'password')
* Usually PDO will swallow errors, to config it to throw errors every time failed, add this:
```php
$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
```
* let the MysQL connection use utf-8
```php
$pdo->exec('SET NAMES "utf8"')
```
* run sql: exec('sql') returns **affectedRows** 
* get result query: query($sql)
* 
