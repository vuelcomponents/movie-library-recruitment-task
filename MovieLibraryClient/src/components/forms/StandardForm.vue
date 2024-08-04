<script setup lang="ts">
import Button from "primevue/button";

defineProps<{
  inputs:string[];
  errorMessages:any;
  v$:any
}>();
const emit = defineEmits<{
  submit:[]
}>()
</script>

<template>
  <section class="flex flex-col gap-2 w-full">
    <div class="flex flex-col gap-1" v-for="inp in inputs" :key="inp">
      <label :for="inp" class="text-sm">{{inp.firstLetterToUpperCase()}}</label>
      <slot :name=" 'input_' + inp "/>
      <div v-for="error of (v$ as any)[inp].$errors" :key="error.$uid">
        <div class="text-sm text-movieTheme-200">
          {{ (errorMessages[inp] as any)[error.$validator] || error.$message }}
        </div>
      </div>
    </div>
    <Button @click="emit('submit')">Save</Button>
  </section>
</template>
