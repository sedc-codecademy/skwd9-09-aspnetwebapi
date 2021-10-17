<template>
    <div>
        <div v-if="isLogged" class="notes">
            <app-note 
                v-for="note in notes" 
                :key="note.id"
                :note='note'>
            </app-note>
        </div>
        <p v-if="!isLogged">It seems you do not have any notes</p>
    </div>
</template>

<script>
    import Note from './Note.vue'

    export default {
        components: {
            appNote: Note
        },
        computed: {
            notes() {
                console.log(this.$store.state.notes.notes)
                return this.$store.state.notes.notes
            },
            isLogged() {
                console.log(this.$store.state.users.isLogged)
                const token = localStorage.getItem('token')
                return token ? true :false;
            }
        }
    }
</script>

<style lang="scss" scoped>
    .notes {
        display: flex;
        flex-wrap: wrap;
    }


</style>