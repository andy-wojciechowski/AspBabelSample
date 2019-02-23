<template>
    <div>
        <div v-for="todo in todos">
            {{todo.Description}}
        </div>
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
        }
    }
};
</script>