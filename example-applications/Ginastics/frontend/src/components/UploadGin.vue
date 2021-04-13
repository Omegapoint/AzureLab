<template>
    <v-form action="">
        <v-container>
            <v-row>
                <v-col cols="12" sm="6" md="3">
                    <v-text-field
                        type="text"
                        name="name"
                        v-model="name"
                        filled
                    />
                </v-col>
                <v-col cols="12" sm="6" md="3">
                    <v-text-field
                        type="text"
                        name="distillery"
                        v-model="distillery"
                        label="Regular"
                        placeholder="Distillery"
                        filled
                    />
                </v-col>
            </v-row>
            <v-row>
                <v-col cols="12" sm="6" md="3">
                    <v-text-field
                        type="text"
                        name="abv"
                        id=""
                        v-model="abv"
                        filled
                /></v-col>
                <v-col cols="12" sm="6" md="3">
                    <v-text-field
                        type="text"
                        name="country"
                        id=""
                        v-model="country"
                        filled
                /></v-col>
            </v-row>
            <v-row>
                <v-btn color="success" class="mr-4" @click="this.uploadGin()"
                    >Submit</v-btn
                >
            </v-row>
        </v-container>
    </v-form>
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
