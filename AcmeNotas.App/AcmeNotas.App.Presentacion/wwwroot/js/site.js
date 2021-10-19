// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function getValue() {
    document.getElementById('TutorID').innerHTML= "<option value = ''>Selecciona un Tutor</option>";
    fetch(`?handler=Tutores`)
    .then((response) => {
        return response.json();
    })
    .then((data) => { 
        Array.prototype.forEach.call(data, function (item,i) {
            document.getElementById('TutorID').innerHTML += `<option value= "${item.value}">${item.text}</option>`
        });
    });
  
    }

