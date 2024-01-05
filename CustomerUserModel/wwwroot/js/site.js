

$(document).ready(function () {
	GetCustomer();

	// Validate form on document ready

});


// Get the Customer List

function GetCustomer() {
	$.ajax({
		url: "/Customer/GetCustomer",
		type: "GET",
		datatype: "json",
		contentType: "application/json;charset=utf=8",
		success: function (response) {
			if (response == null || response == undefined || response.length == 0) {
				var object = '';
				object += '<tr>'
				object += '<td colspan="5"> ' + 'Customer not avaliable' + '</td>'
				object += '</tr>'
				$('#tblBody').html(object)
			} else {
				var object = '';
				$.each(response, function (index, item) {
					object += '<tr>'
					object += '<td>' + item.id + '</td>'
					object += '<td>' + item.firstName + '</td>'
					object += '<td>' + item.lastName + '</td>'
					object += '<td>' + item.phoneNumber + '</td>'
					object += '<td>' + item.email + '</td>'
					object += '<td>' + item.address + '</td>'
					object += '<td>  <a href="#" class="btn btn btn-primary btn-sm m-1" onclick="Edit(' + item.id + ')">Edit</a> <a href="#" class="btn btn btn-danger btn-sm m-1" onclick="Delete(' + item.Id + ')">Delete</a> </td>'
				})
				$('#tblBody').html(object)
			}
		},
		error: function () {
			alert("Uable to render the customer data")
		}
	})
}
function InputValidaction() {
	$("form").validate({
		rules: {
			"FirstName": {
				required: true
			},
			"LastName": {
				required: true
			},
			"Email": {
				required: true,
				email: true
			},
			"Address": {
				required: true
			},
			"Phone": {
				required: true
			},
		},
		messages: {
			"FirstName": {
				required: "Please enter your First Name"
			},
			"Email": {
				required: "Please enter your email address",
				email: "Invalid email address"
			},
			"LastName": {
				required: "Please enter last name"
			},
			"Phone": {
				required: "Please enter your phone number"
			},
			"Address": {
				required: "Please enter your Address"
			}
		},
		errorElement: "span",
		errorClass: "text-danger"
	});

}

// Showing the model 
//$("#AddCustomerBtn").click(function () {
//	$("#customerModal").modal('show')
//})
// Inserting the data 
function Insert() {
	var result = Validate();
	if (result == false) {
		return false;
	}
	var formData = {
		Id: $('input[name="Id"]').val(),
		FirstName: $('input[name="FirstName"]').val(),
		LastName: $('input[name="LastName"]').val(),
		PhoneNumber: $('input[name="PhoneNumber"]').val(),
		Email: $('input[name="Email"]').val(),
		Address: $('input[name="Address"]').val()
	};

	for (var key in formData) {
		if (formData[key].trim() === '') {
			alert('Please fill in all fields.');
			return false;
		}
	}

	var formData = {
		Id: $('input[name="Id"]').val(),
		FirstName: $('input[name="FirstName"]').val(),
		LastName: $('input[name="LastName"]').val(),
		PhoneNumber: $('input[name="PhoneNumber"]').val(),
		Email: $('input[name="Email"]').val(),
		Address: $('input[name="Address"]').val()
	};

	$.ajax({
		url: '/Customer/Insert',
		type: 'POST',
		data: formData,
		success: function (response) {
			if (response == null || response == undefined || response.length == 0) {
				alert('Unable to read the data');
			} else {
				HideModal();
				GetCustomer();
				alert(response);
				console.log(formData)
			}
		},
		error: function () {
			alert("Unable to update the data");
		}
	});
}

// hide Model
function HideModal() {
	ClearInputData();
	$('#customerModal').modal('hide');
	$('body').removeClass('modal-open');
	$('.modal-backdrop').remove();
}


// clear the input values
function ClearInputData() {
	$('input[name="Id"]').val(' '),
		$('input[name="FirstName"]').val(' '),
		$('input[name="LastName"]').val(' '),
		$('input[name="PhoneNumber"]').val(' '),
		$('input[name="Email"]').val(' '),
		$('input[name="Address"]').val(' ')
}

// Get  the modal for Edit
function Edit(id) {
	$.ajax({
		url: '/Customer/Edit?Id=' + id,
		type: 'GET',
		contentType: 'application/json; charset=utf-8',
		datatype: 'json',
		success: function (response) {
			if (response == null || response == undefined) {
				alert('Unable to read the data');
			} else if (response.length == 0) {
				alert("Data not available with the id " + id);
			}
			else {
				$("#customerModal").modal('show');
				$("#modalTitle").text('Update Customer');
				$("#Save").css('display', 'none');
				$("#Update").css('display', 'block');
				$('input[name="Id"]').val(response.id);
				$('input[name="FirstName"]').val(response.firstName);
				$('input[name="LastName"]').val(response.lastName);
				$('input[name="PhoneNumber"]').val(response.phoneNumber);
				$('input[name="Email"]').val(response.email);
				$('input[name="Address"]').val(response.address);
			}
		},
		error: function () {
			alert("Unable to read the data");
		}
	});
}

// update the data
function Update() {
	var result = Validate();

	if (result == false) {
		return false;
	}

	var formData = {
		Id: $('input[name="Id"]').val(),
		FirstName: $('input[name="FirstName"]').val(),
		LastName: $('input[name="LastName"]').val(),
		PhoneNumber: $('input[name="PhoneNumber"]').val(),
		Email: $('input[name="Email"]').val(),
		Address: $('input[name="Address"]').val()
	};

	$.ajax({
		url: '/Customer/Update',
		type: 'POST',
		data: formData,
		success: function (response) {
			if (response == null || response == undefined || response.length == 0) {
				alert('Unable to read the data');
			} else {
				HideModal();
				GetCustomer();
				alert(response);
			}
		},
		error: function () {
			alert("Unable to update the data");
		}
	});
}



// validate input

function Validate() {
	var isValid = true;
	if ($('input[name="FirstName"]').val().trim() == "") {
		$('input[name="FirstName"]').css('border-color', 'Red');
		isValid = false;
	} else {
		$('input[name="FirstName"]').css('border-color', 'lightgrey');
	}
	if ($('input[name="LastName"]').val().trim() == "") {
		$('input[name="LastName"]').css('border-color', 'Red');
		isValid = false;
	} else {
		$('input[name="LastName"]').css('border-color', 'lightgrey');
	}

	if ($('input[name="PhoneNumber"]').val().trim() == "") {
		$('input[name="PhoneNumber"]').css('border-color', 'Red');
		isValid = false;
	} else {
		$('input[name="PhoneNumber"]').css('border-color', 'lightgrey');
	}
	if ($('input[name="Email"]').val().trim() == "") {
		$('input[name="Email"]').css('border-color', 'Red');
		isValid = false;
	} else {
		$('input[name="Email"]').css('border-color', 'lightgrey');
	}
	if ($('input[name="Address"]').val().trim() == "") {
		$('input[name="Address"]').css('border-color', 'Red');
		isValid = false;
	} else {
		$('input[name="Address"]').css('border-color', 'lightgrey');
	}
	return isValid;
}

$('#FirstName').change(function () {
	Validate();
})
$('#LastName').change(function () {
	Validate();
})
$('#PhoneNumber').change(function () {
	Validate();
})
$('#Email').change(function () {
	Validate();
})
$('#Address').change(function () {
	Validate();
})


function FillCities(listCountryCtrl, listCityId) {
	var listCities = $("#" + listCityId);
	listCities.empty();
	var selectCountry = listCountryCtrl.options[listCountryCtrl.selectIndex].value;

	if (selectCountry != null && selectCountry != '') {
		$.getJSON("User/GetCitiesByCountry", { countryId: selectCountry }, function (cities) {
			listCities.append($('<option/>'), { value = cities.value, text = cities.text })
		})
	}
	return;
}