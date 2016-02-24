### Constructor
* SaveFile: mforms.FileChooser(mforms.SaveFile)
* OpenFile: mforms.FileChooser(mforms.OpenFile)


### Useful method
* None set_path(filename):
  * ```filename```: the path you want to use
* None set_ext(dir_name):
  * ```dir_name```: the directory name when you open the dialog
* str get_path():
  * ```return```: your selected path
  * **?**: can select multi-files
  
* bool run_modal(): show the file chooser
  * ```return```: True if you select ok, False if you cancel
