Here are some ideas I got after reading some of plaid and AEminium's paper.

### shall we give the user some chance to control the workflow?
After I read some paper about AEminium, I know it's a language which can make program parallel by compiler so the developer don't need to explicitly express the workflow logic. But the real world experience inspire me to think several real world cases and found it's a better that we can give the user more chance to control the workflow.

Here is a scenario:
> - we have system ```A```
- system ```A``` needs to process 3 tasks: ```task1```,```task2```,```task3``` and then after **all of them finished**, it will sends out an notification. 

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
The issue is actually, ```task1()```, ```task2()```, ```task3()``` share no data with ```send_notification()``` method, they are only **logic related**. So 
the AEminium might consider they can run in parallel. But we need to let ```send_notification()``` run only after the 3 tasks methods finished. So actually we need some **thread join logic**.

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

Here is Some other cases:
> System ```B``` like system ```A``` has 3 tasks but will notify a message out  **once one of 3 tasks finished**. How shall we express the logic?
> System ```C``` needs to let it tasks run one by one, but different tasks share no data.

These case trigger me to think, is it a good idea to introduce some workflow structure?

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

// let the tasks run in synchronous
main(){
  sequence: {
    task1();
    task2();
    task3();
  }
  send_notification();
}
```
One step further, I thought the structure like the following is a good choice to express shedule logic.
```csharp
<shedule_name> [parameters] :{
}
```
So is it a better idea to let user can extend such kind of logic. E.g. they can define a ```"Class"```(here I give the keyword ```schedule```) to define the schedule function:
```csharp
//this a shedule control the max parallel count
schedule limit_parallel {
 // some definition
 ...
}

//use the defined shedule limit_parallel
main(){
  //so only 2 tasks run in parallel at a time.
  limit_parallel(2): {
    task1();
    task2();
    task3();
  }

}
```
Though the details is deeply thought, I still guess AEminium will become more flexible if we have the explicit workflow support.





### Let developer has more control, and Make it More Extended
Though AEminium aimed to supply parallel by free, I thought sometimes, developers want more control over their code. The reason is simple, real world questions can be complex and our parallel algorithmn can't handle every case well. If developer can controll something, they have more chance to make a better solution and avoid some unexpected improvement.

Here I raise a real world example:
- we have several batch job which needs to load differebt data. Each batch job ran in a process(not thread)
- one of the batch job **job_big** consume large amount of CPU resource and last for long time. Other batch job are quite small and takes short time.

The issue is, if **job_big** ran first, it will soon consume all the CPU resource(since we try to let it be as parallel as possible) and might block the following small jobs. The small jobs thus have to wait for the **job_big** finished to start.
Since they ran in different processes, AEminium can't balance them. 

What I mean here is AEminium is great for auto parallel but sometimes we need some control like ```restrain the upper bound of parallel```.

The code might like the following:
```
void main(){
  t1();
  t2();
  t3();
}

```




________________________________
### **Ingnore the following since they are still in draft **

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
Since, the 2 ```m1()``` not related, they will ran in parallel and it's hard to know which method throw out that Exception. It might be strange to call ```m1()``` twice, however, sometimes, the situation is like:
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
and we face similiar situation. (though we can distinguish them from callStack when use debug, but think about some situation with recursive method call)

The lack of support for multi-thread exception handling is common in most current language, so I think if we can add more features for exception handling.


### incorperate some parallel design pattern and implment them in languange level.

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


 
