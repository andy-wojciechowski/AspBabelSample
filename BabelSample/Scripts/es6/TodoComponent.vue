<template>
    <div>
        <input type="text" id="descriptionTextbox" v-on:keyup="createTodo">
        <div v-for="todo in todos">
            <input type="checkbox" v-model="todo.IsDone" v-on:click="updateTodo(todo.Id, $event)">
            {{todo.Description}}
            <button v-on:click="deleteTodo(todo.Id)">Delete</button>
        </div>
        <div id="putConfirmation"></div>
    </div>
</template>
<script>
export default {
    name: 'todo-component',
    created() {
        this.loadData();
    },
    data() {
        return {
            todos: []
        };
    },
    methods: {
        loadData() {
            let component = this;
            fetch(`http://${window.location.hostname}:${window.location.port}/api/todos`)
                .then(resp => resp.json())
                .then(function (data) {
                    component.todos = data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        createTodo: function(e) {
            if(e.keyCode === 13) {
                let component = this;
                let data = document.getElementById('descriptionTextbox').value;
                fetch(`http://${window.location.hostname}:${window.location.port}/api/todos`, {
                    method: 'POST', 
                    body: JSON.stringify(data),
                    headers: {
                        "Content-Type": "application/json"
                    }
                })
                .then(resp => resp.json())
                .then(function(data) {
                    component.todos.push(data);
                })
                .catch(function(error) {
                    console.log(error);
                });
            }
        },
        deleteTodo(id) {
            let component = this;
            fetch(`http://${window.location.hostname}:${window.location.port}/api/todos`, {
                method: 'DELETE',
                body: JSON.stringify(id),
                headers: {
                    "Content-Type": "application/json"
                }
            })
            .then(resp => resp.json())
            .then(function(data) {
                if(data) {
                    component.todos = component.todos.filter(x => x.Id !== id);
                }
            })
            .catch(function(error) {
                console.log(error);
            });
        },
        updateTodo: function(id, event) {
            let data = {
                Id: id,
                IsDone: event.target.isChecked
            };
            fetch(`http://${window.location.hostname}:${window.location.port}/api/todos`, {
                method: 'PUT',
                body: JSON.stringify(data),
                headers: {
                    "Content-Type": "application/json"
                }
            })
            .then(resp => resp.json())
            .then(function(data) {
                document.getElementById('putConfirmation').innerHTML = `${data} has been updated`;
            })
            .catch(function(error) {
                console.log(error);
            });
        }
    }
};
</script>