### pip -- python's package manager

### setup
set it's installed location to path
%Python%Scripts\pip.exe


### use
$ pip install PackageName
This is the default and installs the latest version of the package:


$ pip install PackageName==1.0.4
Using the ==parameter, you can install a specific version of the package. In this case, 
that is 1.0.4. Use the following command to install the package with a version number:


$ pip install 'PackageName>=1.0.4' # minimum version
Use the above command when you are not sure of the package version you are going 
to install but have an idea that you need the minimum version of the library


pip freeze
pip install -r filename


