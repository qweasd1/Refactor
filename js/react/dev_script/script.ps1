### Component
$componentName = "Button"
$states = "t1"


$__init_state = 

function init_states($states){
if($states){
return @"
            getInitialState: function(){
                return {
$(($states -split "," | %{ "$("`t" * 5)$($_.trim()):`"`""}) -join ",`n")
                }
            },
"@
}
else
{
    return ""
}

}

function optional(){
    $args -join "`r`n"
}


@"
var $componentName = React.createClass({
$(optional (init_states($states)))
            render: function(){
                return (
                        <div>
                
                        </div>
                )
            }
        })
"@ | Out-Clipboard
