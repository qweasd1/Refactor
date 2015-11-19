Here are some ideas I got after reading some of plaid and AEminium's paper.

### shall we explicitly specify some **'join'** logic?
I think in reality, it's common to have the following scenario:
> - we have system ```A```
- system ```A``` need to process 3 tasks: ```task1```,```task2```,```task3``` and then after all of them finished sends out an notification 

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
- System ```B``` like system ```A``` has 3 tasks but will notify a message out when **either one of 3 tasks finished**. How shall we express the logic?

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
 
Not automatically
