<script setup lang="ts">
import DataGrid from '@/components/DataGrid.vue';
import { useJobs } from '@/store/useJobs';
import { ref, watchEffect } from 'vue'

const searchQuery = ref('')
const columns = [
    {
        name: 'Job Id',
        dataIndex: 'jobId',
        key: 'jobId',
    },
    {
        title: 'Job Title',
        dataIndex: 'jobTitle',
        key: 'jobTitle',
    },
    {
        title: 'Min Salary',
        dataIndex: 'minSalary',
        key: 'minSalary',
    },
    {
        title: 'Max Salary',
        key: 'maxSalary',
        dataIndex: 'maxSalary',
    },
    {
        title: 'Action',
        key: 'action',
    },
];

const store = useJobs()

watchEffect(async () => {
    await store.getJobs()
})

</script>

<template>
	<form id="search">
		Search <input name="query" v-model="searchQuery">
	</form>
	<DataGrid :columns="columns" :data="store.jobs" />
</template>