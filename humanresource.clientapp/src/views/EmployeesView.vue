<script setup lang="ts">
import DemoGrid from '../components/Grid.vue'
import Modal from '@/components/Modal.vue';
import type Employee from '@/models/Employee';
import { ref, watchEffect } from 'vue'

const deletingEmployeeId = ref(null);
const editingEmployee = ref<Employee>();
const searchQuery = ref('')
const showDeleteModal = ref(false);
const showEditModal = ref(false);
const gridColumns = [
    'employeeId',
    'firstName',
    'lastName',
    'email',
    'phoneNumber',
    'hireDate',
    'jobId',
    'salary',
    'commissionPct',
    'managerId',
    'departmentId'
];
const gridData = ref<Employee[]>([]);

watchEffect(async () => {
    const url = `/api/employee`
    gridData.value = await (await fetch(url)).json()
})

function testDelete(entry: any) {
    deletingEmployeeId.value = entry.employeeId;
    showDeleteModal.value = true;
}

async function deleteEmployee() {
    const url = `/api/employee/${deletingEmployeeId.value}`
    const headers = {
        'Content-Type': 'application/json',
    };
    const response = await fetch(url,
        {
            method: 'DELETE',
            headers,
        })
    if (response.status === 200 && response.ok) {
        gridData.value = gridData.value.filter(t => t.employeeId !== deletingEmployeeId.value)
        deletingEmployeeId.value = null;
        showDeleteModal.value = false;
    }
}

function testEdit(entry: Employee) {
    editingEmployee.value = {...entry}
    showEditModal.value = true;
}

</script>

<template>
    <div>
        <form id="search">
            Search <input name="query" v-model="searchQuery">
        </form>
        <button id="show-modal" @click="showDeleteModal = true">Add Employee</button>
    </div>
    <DemoGrid :data="gridData" :columns="gridColumns" :filter-key="searchQuery" :showActions="true" @delete="testDelete"
        @edit="testEdit" />

    <!-- Delete Modal -->
    <Teleport to="body">
        <!-- use the modal component, pass in the prop -->
        <Modal :show="showDeleteModal" @close="showDeleteModal = false">
            <template #header>
                <h3>Delete Employee</h3>
            </template>
            <template #body>
                <h3>Are you sure deleting employee?</h3>
            </template>
            <template #footer>
                <button @click="deleteEmployee">Delete</button>
                <button @click="showDeleteModal = !showDeleteModal">Cancel</button>
            </template>
        </Modal>
    </Teleport>

    <!-- Editing Modal -->
    <Teleport to="body">
        <!-- use the modal component, pass in the prop -->
        <Modal :show="showEditModal" @close="showEditModal = false">
            <template #header>
                <h3>Update Employee</h3>
            </template>
            <template #body>
                <form>
                    <input type="text" name="firstName" v-model="editingEmployee!.firstName">
                    <input type="text" name="lastName" v-model="editingEmployee!.lastName">
                    <input type="email" name="email" v-model="editingEmployee!.email">
                    <input type="text" name="phoneNumber" v-model="editingEmployee!.phoneNumber">
                    <input type="date" name="hireDate" v-model="editingEmployee!.hireDate">
                    <input type="text" name="jobId" v-model="editingEmployee!.jobId">
                    <input type="number" name="salary" v-model="editingEmployee!.salary">
                    <input type="number" name="commissionPct" v-model="editingEmployee!.commissionPct">
                    <input type="text" name="managerId" v-model="editingEmployee!.managerId">
                    <input type="text" name="departmentId" v-model="editingEmployee!.departmentId">
                </form>
            </template>
            <template #footer>
                <button @click="showEditModal = !showEditModal">Cancel</button>
            </template>
        </Modal>
    </Teleport>
</template>