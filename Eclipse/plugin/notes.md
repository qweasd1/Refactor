### Eclipse




#### questions
* how we get the service
	* from static method on Plugin Class
	* from site.getService
	* from Platform, PlatformUI
		* get active window, page, editor, view
	
* how to use DI in eclipse plugin dev
* how to uninstall plugin: 
	* prod: Help -> install details -> uninstall
	
* [...TODO] how to write a helper plugin which expose package to be used by other plugin
	
* plugin views and how can they help us with tasks

* how to create a new workbench wizard
	* create wizard components
		* wizard class
			* subclass of Wizard
			* implement INewWizard
		* wizardPage class
			* subclass of WizardPage
			* create content: override the createControl method
			* remember to invoke setControl method, otherwise the wizard can't work
		* composite wizard with wizardPage
			* override addPages() in wizard
				* use addPage to add page
				* [?] will addPages be called only once?
		* others
			* active finish button: setPageComplete()
			* wizard is used to perform action but page is used to gather infos
				* expose methodd on page to let wizard fetch infos
				* inject an info object into the page when create 
	* add the wizard to newWizard extension point
##### give class search its plugin package
class -> package name->ctrl+shift+a open PDE window, search package name -> plugin full name


##### [?!] get register infos for plugin points?




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


##### add dependency on native jar to plugin
* maybe helpful: http://help.eclipse.org/juno/index.jsp?topic=/org.eclipse.pde.doc.user/guide/tools/editors/manifest_editor/dependencies.htm
	* [!] we can see the source code for this Wizard to see what happened
* use plugin from jar file to generate a plugin project
	* add the jars you need
	* export the package you need to ref
* add dependency to the plugin you create
	

##### how to deploy
	
### e4 model


#####  SWT layout
* in GridLayout, how to set a label to the top ,when there are 1 control in the same row but much heighter than label
