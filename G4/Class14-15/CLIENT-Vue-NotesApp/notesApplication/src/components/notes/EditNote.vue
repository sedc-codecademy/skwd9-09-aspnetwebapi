<template>
    <div>
        <h3>Edit Note</h3>
        <form @submit.prevent="editNote">
            <div class="mb-3">
                <label for="title" class="form-label">Title</label>
                <input type="text" class="form-control" id="title" v-model="title" required> 
            </div>
            <div class="mb-3">
                  <label for="text" class="form-label">Text</label>
                  <textarea class="form-control" id="text" rows="3" v-model="text" required></textarea>
            </div>
            <button type="submit" class="btn btn-primary" @click="editNote">Edit Note</button>
        </form>
        <!-- <p>{{note.title}}</p>
        <p>{{note.text}}</p> -->
    </div>
</template>

<script>
export default {
    data() {
        return {
            title: '',
            text: '',
        }
    },
    computed: {
        note() {
            return this.$store.state.notes.note
        }
    },
    methods: {
        editNote() {
            this.$store.dispatch('noteEdit', {
                title: this.title,
                text: this.text,
                noteId: this.note.noteId,
                userId: this.note.userId
            }) 
            this.$router.push({path: '/dashboard/notes'})
        }
    }
}
</script>