<script setup lang="ts">
const emit = defineEmits<{
  onLeftButtonClick:[]
  onRightButtonClick:[]
}>();
</script>

<template>
  <header class="h-10 grid grid-cols-4 gap-x-0.5 mb-2">
    <div class="col-span-2 flex gap-2">
      <button class="w-full h-full bg-movieTheme-300 flex items-center px-5 rounded-sm justify-center"
              @click="emit('onLeftButtonClick')"
      >
        <slot name="leftButton"/>
      </button>
      <button class="w-full h-full bg-movieTheme-100 flex items-center px-5 rounded-sm justify-center"
              @click="emit('onRightButtonClick')"
      >
        <slot name="rightButton"/>
      </button>
    </div>

    <div class="col-span-3">
      <div class="w-full h-full bg-surface-100/50 flex items-center px-5 rounded-sm">
        <slot name="content"/>
      </div>
    </div>
  </header>
</template>
