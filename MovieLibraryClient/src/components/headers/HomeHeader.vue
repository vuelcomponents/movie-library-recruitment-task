<template>
  <header class="h-20 w-full shadow-md font-mulish text-5xl flex justify-between gap-4">
    <div class="h-full w-fit flex items-center">
      <div class="flex items-center gap-2">
        <i class="mdi mdi-movie-open text-movieTheme-200"/>
        <span class="text-xl">MOVLIST</span>
      </div>
    </div>
    <div class="w-full h-full flex items-center justify-start">
      <slot name="menu"/>
    </div>
    <div class="w-full h-full flex items-center justify-end">
      <slot name="corner"/>
    </div>
  </header>
</template>
