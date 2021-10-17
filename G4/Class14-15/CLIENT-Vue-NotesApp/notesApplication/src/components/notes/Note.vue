<template>
    <div class="card" style="width: 26rem;">
        <div class="card-body">
            <h5 class="card-title">{{note.tag}}</h5>
            <p class="card-text">{{note.text}}</p>
            <router-link :to="'/dashboard/noteDetail/' + this.note.id"><a class="btn btn-primary">See details</a></router-link>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
            }
        },

        props: ['note'],
    }
</script>

<style lang="scss" >
    .card {
        margin: 20px;

        router-link {
            cursor: pointer;
        }
    }
</style>