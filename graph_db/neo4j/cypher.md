### Basic

#### match variable path
node -[<Label> ( '|' <Label>)* '*' INT '..' INT]-node

#### list comprehension
FILTER(f in nodes(path)) WHERE <Label> In labels(f) as <alias>
EXTRACT(c in cities | city.name) as <alias>



### Index
create index on :<Label>(<Property>)



