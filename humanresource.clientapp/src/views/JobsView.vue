<script setup lang="ts">
import DemoGrid from '../components/Grid.vue'
import { ref, watchEffect } from 'vue'

const searchQuery = ref('')
const gridColumns = [
    "jobId",
    "jobTitle",
    "minSalary",
    "maxSalary"
];
const gridData = ref([]);

watchEffect(async () => {
    const url = `/api/job`
    gridData.value = await (await fetch(url)).json()
})

</script>

<template>
	<form id="search">
		Search <input name="query" v-model="searchQuery">
	</form>
	<DemoGrid 
		:data="gridData"
		:columns="gridColumns"
		:filter-key="searchQuery"
	/>
</template>