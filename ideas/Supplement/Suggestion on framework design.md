### how to design a module
*This is a short essay about framework(module) design*

**Content**
- What's a module?
- Before everything, select a goal with your module
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

##### What is a module?
To answer a question, to make it clear first. Before we talk anything about how to design a framework, I want pust some useful constraints on the module definition: 
- A module should have only **a single root Domain Model** export from your module along with  **an optional config Class** use to controll the Doman Model's behavior.
- A module root Domain Model should not store any stateful object from a different domain. But it can accept the stateful object on the root model's method.

here are several good examples for such definition:

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
