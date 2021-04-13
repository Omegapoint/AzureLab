<template>
    <form action="">
        <input type="text" name="name" v-model="name" />
        <input type="text" name="distillery" v-model="distillery" />
        <input type="text" name="abv" id="" v-model="abv" />
        <input type="text" name="country" id="" v-model="country" />
        <button @click="this.uploadGin()">Submit</button>
    </form>
</template>

<script>
export default {
    name: "Gin form",
    data: function () {
        return {
            name: "",
            distillery: "",
            abv: "",
            country: "",
        };
    },
    methods: {
        uploadGin: async function () {
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(this.data()),
            };
            const res = await fetch("URL", requestOptions);
            const data = await res.json();
            console.log(this.data());
        },
    },
};
</script>
