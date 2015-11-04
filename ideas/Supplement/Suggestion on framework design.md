### how to design a module
*This is a short essay about framework(module) design*

**Content**
- Set a Canvas
- Clear your goal
- Make your framework easy to use
  - Single root
  - Similar structure(make you familiar with it)
  - has default settings, implement elegant way to override them
  - make holes(template method, template) in your framework
  - make trivil things more simple, let complex things not complex, let those hard to handle can turn back to what we can do
  - should be easy to extend
- keep those things in mind
   - don't do to much(Groovy as a sample, it can parse its code as java, but does it really necessary? It will definitely complicate the complier algorithm.)
   - error handling in your mind!(don't throw the origin exception)
- framework on demand
  - let the framework behave what you want.(give your user more option)
    - bootstrap()
    - hanbao()
  - build trivial adapter to quickly incorperate the framework in new system.

##### Set a Canvas?
Module is the fundamental building block of software. But since it can contains a lof of different things, it can be very complex. However putting some constraints on it to form a special kind of module(here, the function module) can make it easier to analysis, develop, extends and test. The following  2 constraints are what I put on module to form the 'function module': 
- A module should have only **a single root Domain Model** export from your module along with  **an optional config Class** use to controll the Doman Model's behavior.
- A module root Domain Model should not store any stateful object from a different domain. But it can accept the stateful object on the root model's method.

here are several examples for such definition:

<table>
    <th>
      <tr>
          <td>Framework</td>
          <td>Root Object</td>
          <td>Config</td>
      </tr>
    </th>
    <tbody>
      <tr>
        <td>jQuery</td>
        <td>jQuery</td>
        <td></td>
      </tr>
      <tr>
        <td>CsvHelper(C#)</td>
        <td>CsvReader</td>
        <td>CsvConfiguration</td>
      </tr>
      <tr>
        <td>Regex(C#)</td>
        <td>Regex</td>
        <td>RegexOptions</td>
      </tr>
    </tbody>
</table>

As you can see, many popular existing frameworks meets our constraint.
The reasons for the  two constraint are as following:
- Only one Domain Model exports can reduce the coupling when other modules rely on the module you write
- Only one model exports can make your user has a single entrance to your module.(it's simpler to remember one, it's harder to remember many)
- Only one model exprots can let code analysis tools working more easier.
- Storing no exotic stateful object will protect our module from easily affected by exotic states change. 
- Storing no exotic stateful object can let your module easier to test.(Your module's only care its inner state)

Though we set constraint on our module, it's still powerfull. We have only one Domain Model, but we can add the many domain method on your module. We can also use that optional config object to control your module's behavior.

So now we have set a good 'canvas' for our module

###### Clear your goal
Before you move on any steps to write your module, do think about what your module will do. If you are not clear with then try to write some prototype code to mimic the function you want and then re-think this question. But finally at a point, you will realize what's your goal and your goal can be mapped to some behavior tests! 

let's use a good example to show this
if we want 
