Issues might:
Case: when there are if-branch
```csharp
public bool methodA()

public void methodB()

// on another thread
public void methodC()

public void main()
{
  if(methodA())
  {
     methodB();
  }
}

```

My Understanding:
Permisson join: phase
