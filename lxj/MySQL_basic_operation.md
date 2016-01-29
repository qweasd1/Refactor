### Basic Funtion:
* **get id for auto-increament column**: LAST_INSERT_ID()

### Run sql from **mysql** client
* mysql-e "SELECT * FROM limbs WHERE legs=0" <database> -h <host>

### Restore Data
* Save the bakcup file: mysqldump -h localhost -u cbuser -p cookbook > cookbook.sql


### run script from cmd
* mysql cookbook < limbs.sql


### common script
* drop when object exists: ```DROP TABLE IF EXISTS limbs```;


### Insert(ignore, on duplicate key replace to)
* ignore http://www.server110.com/mysql/201310/2453.html
* ignore + auto_increment: http://www.2cto.com/database/201108/99073.html


### Set Variable in Select Query
* select @v := <expr>  http://stackoverflow.com/questions/3888735/mysql-set-user-variable-from-result-of-query


### Create SP
* http://blog.sina.com.cn/s/blog_98a0937f0100zgdf.html


### If exist
* if exist 
```sql
delimiter$$
create procedure gg()
begin
if exists(select column_name from information_schema.columns where 
table_schema='test' and table_name='t_user' andn column_name='point')
then
select 'tt';
end if;
end$$
```
