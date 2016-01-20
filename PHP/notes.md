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
* foreach
```php
foreach($array as $item){

}

foreach($array as $key => $value){

}
```

### Html Template

* add <meta charset="utf-8"> to the head of your html



### Http requrest
* $_REQUEST will contain both variables defined in $_GET and $_POST
* redirect: set the response header using: **header('Location: URL')**. 
  * You can use a "." to represent the current directory 
  * You can use $_SERVER['PHP_SELF'] to reference the url your php script is current running.

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
```php
$result = $pdo->query($sql);
while ($row = $result->fetch())
{
     //* access value of one column
    $row['joketext']
}
* using prepare statement: 
```php
$pdo->prepare("...where id = :id");
$pdo->bindValue(":id","123");
$pdo->execute();
```
  
```


### Very common issues:
* key not existing in array
* know if DB operation successful
