<script setup lang="ts">
import DataGrid from '@/components/DataGrid.vue';
import { ref, watchEffect } from 'vue'

const searchQuery = ref('')

const columns = [
    {
        name: 'Location Id',
        dataIndex: 'locationId',
        key: 'locationId',
    },
    {
        title: 'Street Address',
        dataIndex: 'streetAddress',
        key: 'streetAddress',
    },
    {
        title: 'Postal Code',
        dataIndex: 'postalCode',
        key: 'postalCode',
    },
    {
        title: 'State Province',
        key: 'stateProvince',
        dataIndex: 'stateProvince',
    },
    {
        title: 'Country Id',
        key: 'countryId',
        dataIndex: 'countryId',
    },
    {
        title: 'Action',
        key: 'action',
    },
];

const gridData = ref([]);

watchEffect(async () => {
    const url = `/api/location`
    gridData.value = await (await fetch(url)).json()
})

</script>

<template>
	<form id="search">
		Search <input name="query" v-model="searchQuery">
	</form>
	<DataGrid
		:data="gridData"
		:columns="columns"
	/>
</template>