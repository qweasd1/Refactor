Here are some ideas I got after reading some of plaid and AEminium's paper.

### shall we explicitly specify some **'join'** logic?
I think in reality, it's common to have the following scenario:
> - we have system ```A```
- system ```A``` needs to process 3 tasks: ```task1```,```task2```,```task3``` and then after **all of them finished** sends out an notification 

We can convert this scenario to the following code:
```csharp
void task1(){...}
void task2(){...}
void task3(){...}
void send_notification(){...}

//the main method
void main(){
  task1();
  task2();
  task3();
  
  send_notification();
}
```
The issue is actually, ```task1()```, ```task2()```, ```task3()``` share no data with ```send_notification()``` method, so 
the AEminium might consider they can run in parallel. But we need to let ```send_notification()``` run only after the 3 tasks method finished. So actually we need some **thread join logic**.

Of course we can use a workaround like the following:
```csharp

void task1(unique bool flag){...}
void task2(unique bool flag){...}
void task3(unique bool flag){...}
void send_notification(unique bool flag_task1, unique bool flag_task2, unique bool flag_task3){...}


//the main method
void main(){
  unique bool flag_task1 = false;
  unique bool flag_task2 = false;
  unique bool flag_task3 = false;
  
  task1(flag_task1);
  task2(flag_task2);
  task3(flag_task3);
  
  send_notification(flag_task1, flag_task2, flag_task3);
}
```
But seems it's not that convenient.

In another example:
> - System ```B``` like system ```A``` has 3 tasks but will notify a message out  **once one of 3 tasks finished**. How shall we express the logic?

So, maybe we can introduce some structure to express the **join** logic.

maybe something like the following
```csharp
// wait all tasks to finish then go on
main(){
  waitall: {
    task1();
    task2();
    task3();
  }
  send_notification();
}

// wait any tasks to finish then go on
main(){
  waitany: {
    task1();
    task2();
    task3();
  }
  send_notification();
}
```

### Exception Handling
Currently, I haven't read the topic about the exception handling logic in AEminium. But from my personal experience, Exceptions in multi-thread can be not easy to handle. Here is an example:
```csharp
void m1(){
  throw new Exception();
}
//assumpt we have the exception handling logic in AEminium
void main(){
  try{ 
    m1()
    m1()
  }catch(Exception ex){
    ...
  }
}
```
it's hard to know which method throw out that Exception. It might be strange to call ```m1()``` twice, however, sometimes, the situation is like:
```csharp
void m1(){
  throw new Exception();
}

void m2(){
  m1()
}

void main(){
  try{ 
    m1()
    m2()
  }catch(Exception ex){
    ...
  }
}
```
and we face similiar situation. (though we can distinguish them from callStack, but think about some situation with recursive method call)

I think if we can add some features for exception handling will be quite helpful.(I experience the pain for the lacking in my daily development). 


### 


________________________________
### Ingnore the following since they are still in draft 


### When the method
I'm very curious about the **concrete algorithm** we use to parallel method in ```AEminium```

Here is some cases I thought might be interesting:
##### Case 1

```csharp
class test
{
  private unique int field;
  
  //implicitly used member variable field
  void m1(){
    field = 1
  }
  
  void m2(){
    field = 2
  }
  
  
  //or more complex like
  void m3(){
     ...// some code do nothing related with member variable: field. So can be parallel indead
     m2();
  }
  
  void main(){
     m1();
     m3();
  }
}
```


 
