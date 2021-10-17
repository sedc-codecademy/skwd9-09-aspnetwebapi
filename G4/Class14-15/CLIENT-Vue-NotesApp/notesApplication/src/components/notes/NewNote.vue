<template>
    <div>
        <h3>Add New Note</h3>
        <form @submit.prevent="newNote">
            
            <div class="mb-3">
                  <label for="text" class="form-label">Text</label>
                  <textarea class="form-control" id="text" rows="3" v-model="text" required></textarea>
            </div>
            <div class="mb-3">
                <label for="color" class="form-label">Color</label>
                <input type="text" class="form-control" id="color" v-model="color" required> 
            </div>
            <div class="mb-3">
                <label for="tag" class="form-label">Tag</label>
                <input type="text" class="form-control" id="tag" v-model="tag" required> 
            </div>
            <button type="submit" class="btn btn-primary" @click="newNote">Add note</button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                text: '',
                color: '',
                tag: void 0
            }
        },
        computed: {            
            userLogged() {
                return this.$store.state.users.isLogged
            },
            notes() {
                return this.$store.state.notes.notes
            }
        },
        methods: {
            newNote() {
               this.$store.dispatch('addNote', {
                    text: this.text, 
                    color: this.color,
                    tag: parseInt(this.tag)
                }) 
                this.$router.push('notes')
            }
        }
    }
</script>