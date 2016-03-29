## Eclipse Plugin


##### give class search its plugin package
class -> package name->ctrl+shift+a open PDE window, search package name -> plugin full name

##### get selection in explorer
* alt+shift+F1: show component's source plugin to find its viewId
* use the following code to get the selection
```java
//this is the view part
ISelectionService service = this.getSite().getService(ISelectionService.class);
ISelection selection = service.getSelection();
```

##### view
* how to export selection in view as selectionProvider so ISelectionService.getSelection() can access it




org.eclipse.jdt.ui.PackageExplorer

org.eclipse.jdt.ui.CompilationUnitEditor


##### add dependency jar to plugin
* maybe helpful: http://help.eclipse.org/juno/index.jsp?topic=/org.eclipse.pde.doc.user/guide/tools/editors/manifest_editor/dependencies.htm
* use plugin from jar file to generate a plugin project
	* add the jars you need
	* export the package you need to ref
* add dependency to the plugin you create
	
* [?] how to package?
