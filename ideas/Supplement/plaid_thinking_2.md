



### Compatible with existing language and framework.
I read from paper that Plaid is design to be a a general language and AEminium is based on it. And when we push AEminium to the existing industry environment, people will be happy if they can re-use the existing Java library or framework. So we might face issues like we invoke **thread-insafe**


### Real World Issue
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
