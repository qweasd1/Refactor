### Constructor
```python
newTextBox(mforms.VerticalScrollBar)
newTextBox(mforms.HorizontalScrollBar)
newTextBox(mforms.BothScrollBars)
newTextBox(mforms.SmallScrollBars)
newTextBox(mforms.NoScrollBar)
newTextBox(option1 + option2)
```
### set_size to show


### method
* append_text(text:str)
* append_text_and_scroll(text:str)
* ?(how to use encoding)append_text_with_encoding(text:str, encoding)
* ?()append_text_with_encoding_and_scroll
* clear() 
* ?(takes 2 parameters but don't know which 2)get_selected_range
* set_value(text:str): set the content of the TextBox
* ?(not try)set_bordered
* ?(not try)set_monospaced
* ?(not try)set_padding
* set_read_only(is_read_only:bool)

### event
* add_changed_callback(()->{}): 
