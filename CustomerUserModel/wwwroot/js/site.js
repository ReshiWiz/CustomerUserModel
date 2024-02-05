$(document).ready(function () {

	fetchTodos();
});

function Adder() {
	$("#cascade_Modal").modal("show");
}

// feteching the data from SQL as json format 
function fetchTodos() {
	$.ajax({
		url: 'TodoList/FetcherTodos',
		type: 'GET',
		success: function (data) {
			displayTodos(data);
			console.log(data)
		}
	});
}
// listing the task in the table

function displayTodos(todos) {
	$('#todoList').empty();
	$.each(todos, function (index, todo) {
		var taskItem = $('<li style="' + (todo.IsCompleted ? "text-decoration: line-through;" : "") + '">' + todo.title + ' <a href="#" onclick="deleteTodo(' + todo.id + ')">Delete</a></li>');
		$('#todoList').append(taskItem);
	});
}

// Deleting the todo Task
function deleteTodo(id) {
	$.ajax({
		url: 'TodoList/DeleteTodo/' + id,
		type: 'POST',
		success: function () {
			console.log(window.location.href)
			fetchTodos();
		}
	})
}


function Printer() {
	const documentModel = document.createElement("div");
	const table = document.createElement("table");

	const thead = document.createElement("thead");
	(table).appendChild(thead);
	let i = 0;
	while (i < 10) {
		const th = document.createElement("th");
		th.textContent = "Header " + i;
		thead.appendChild(th);
		i++;
	}
	documentModel.appendChild(table);
	document.body.appendChild(documentModel);
}

// Call the Printer function
