### Intention
use as a selection for options

### constructor
```python
mforms.newSelector()
```
### set_size to show


### specific method:
* ```add_items([str...])```: add options to the selector. input is a list(str)
* ```add_item```: 
* ```add_changed_callback(cb)```: cb has no input, called when select item change
* ```index_of_item_with_title(item: str)```: get the index of the specific item
* ```get_selected_index()```: 
* ```set_selected(index:int)```: set the index item selected 
* ```set_value(item: str)```: give item and select it. if item not exist, select index 0

