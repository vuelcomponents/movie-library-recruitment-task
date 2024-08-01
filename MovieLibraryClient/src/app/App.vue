<script setup lang="ts">
import HomeHeader from "@/components/headers/HomeHeader.vue";
import HomeLayout from "@/components/layouts/HomeLayout.vue";
import Sidebar30p from "@/components/sidebars/Sidebar30p.vue";
</script>

<template>
  <HomeLayout>
    <template #header>
      <HomeHeader />
    </template>
    <template #sidebar>
      <Sidebar30p></Sidebar30p>
    </template>
    <template #body>
      <router-view />
    </template>
    <template #footer> </template>
  </HomeLayout>
</template>
