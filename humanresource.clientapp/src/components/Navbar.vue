<script setup lang="ts">
import { RouterLink } from 'vue-router'

</script>

<template>
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/employees">Employees</RouterLink>
        <RouterLink to="/departments">Departments</RouterLink>
        <RouterLink to="/jobs">Jobs</RouterLink>
        <RouterLink to="/locations">Locations</RouterLink>
        <RouterLink to="/regions">Regions</RouterLink>
        <RouterLink to="/about">About</RouterLink>
      </nav>
</template>

<style>
nav {
    display: flex;
    width: 100%;
    font-size: 18px;
    margin-top: 2rem;
    gap: 8px;
}

nav a.router-link-exact-active {
  /* color: var(--color-text); */
  color: aquamarine;
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

</style>