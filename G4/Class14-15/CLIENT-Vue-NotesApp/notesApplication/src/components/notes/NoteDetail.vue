<template>
    <div class="note-detail">
        <h3 class="details">Note Details</h3>
        <!-- <p>This note ID: {{id}}</p> -->
        <p>{{note.id}}</p>
        <p>{{note.color}}</p>
        <p>{{note.text}}</p>
        <b-button variant="info" @click="editNote">Update</b-button>
        <b-button variant="danger" @click="deleteNote">Delete</b-button>
    </div>
</template>

<script>
    export default {
        data() {
            return {
               id: this.$route.params.id 
            }
        },  
        computed: {
            note() {
                console.log(this.$store.getters.notes.find(x => x.id === this.id))
                return this.$store.getters.notes.find(x => x.id === this.id)
            }
        },
        methods: {
            deleteNote() {
                this.$store.dispatch('removeNote', this.note)
                this.$router.push({path: '/dashboard/notes'})
            },
            editNote() {
                this.$router.push({path: '/dashboard/editNote/'})
            }
        },
        created() {
            this.$store.dispatch('getNote', {
                    id: this.id  
            }) 
         }   
    }
</script>

<style lang="scss" scoped>

</style>